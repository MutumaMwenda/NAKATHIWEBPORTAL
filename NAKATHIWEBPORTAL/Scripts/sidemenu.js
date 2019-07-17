function getSideMenu(opt) {
    var sctrl;
    var gid = opt.id;
    var grid = $('#' + gid);
    var cont = grid.find('.awe-content');

    function initMenuSeach() {

        var txt = $('#' + opt.src);

        function onenter(e, item) {
            e.preventDefault();
            if (item.length) {
                item[0].click();
            }
        }

        function topFunc() {
            $(window).scrollTop($(window).scrollTop() - 10);
        }

        function botFunc() {
            if ((cont.offset().top + cont.height() + 50) > ($(window).scrollTop() + $(window).height())) {
                $(window).scrollTop($(window).scrollTop() + 10);
            }
        }

        var sctrl = awem.slist(cont, { sel: '.awe-row', enter: onenter, fcls: 'awe-selected', sc: 'n', topf: topFunc, botf: botFunc });

        var keyHandled;
        txt.parent().find('.awe-display')
            .keydown(function (e) {
                if (sctrl.keyh(e)) {
                    keyHandled = 1;
                }
            }).keyup(function () {
                if (!keyHandled) {
                    opt.keyupf && opt.keyupf();
                    grid.data('api').load();
                    sctrl.autofocus();
                }

                keyHandled = 0;
            })
            .on('focusin', function () { sctrl.autofocus(); })
            .on('blur', sctrl.remf);

        return sctrl;
    }

    function scrollToSel() {
        var menuc = cont;
        var sel = menuc.find('.selected');
        if (sel.length) {
            sctrl.scrollTo(menuc.find('.selected'));
        } else {
            sctrl.scrollTo(menuc.find('.awe-row'));
        }
    }
    
    function seth() {
        if (!grid.length) return;
        if ($(window).width() <= 767) {
            awem.setgh(grid, 0);
            return;
        }

        var gridh = $(window).height() - $('#header').outerHeight() - 50;
        awem.setgh(grid, gridh);
    }

    return {
        init: function () {
            sctrl = initMenuSeach();
            seth();
            var skey = gid + 'menust';
            var st = sessionStorage && sessionStorage.getItem(skey);
            if (st) {
                cont.scrollTop(st);
            }

            scrollToSel();

            cont.on('scroll', function () {
                sessionStorage && sessionStorage.setItem(skey, cont.scrollTop());
            });
        },
        setHeight: seth
    };
}

function getMenuGridFunc() {
    var menuNodes;

    function addParentsTo(res, node, all) {
        if (node.ParentId) {
            var isFound;
            $.each(res, function (_, o) {
                if (o.Id == node.ParentId) {
                    isFound = true;
                    return false;
                }
            });

            if (!isFound) {
                var parent = $.grep(all, function (o) { return o.Id == node.ParentId; })[0];
                res.push(parent);
                addParentsTo(res, parent, all);
            }
        }
    }

    function equals(a, b) {
        return new RegExp("^" + a + "$", "i").test(b);
    }

    function buildMenuGridModel(g) {
        var search = (g.search || '').trim();
        
        // find selected
        var selectedItems = $.grep(menuNodes, function (o) {
            o.Selected = '';
            return equals(g.action, o.Action) &&
                equals(g.controller, o.Controller);
        });

        if (selectedItems.length > 1) {
            var anch = window.location.hash.substr(0);

            var anchsli = $.grep(selectedItems, function (o) {
                return equals(anch, o.Anchor);
            });

            if (anchsli.length) {
                selectedItems = anchsli.slice(0);
            }
        }

        if (selectedItems.length) {
            selectedItems[0].Selected = "selected";
            $.each(selectedItems, function (_, item) {
                addParentsTo(selectedItems, item, menuNodes);
            });
        }

        $.each(selectedItems, function (_, o) {
            o.IsNodeSelected = true;
        });

        var words = search.split(" ");

        var regs = $.map(words, function (w) {
            return new RegExp(w, "i");
        });

        var regsl = regs.length;

        var result = $.grep(menuNodes, function (node) {
            var matches = 0;
            var s = node.Keywords + ' ' + node.Name;

            $.each(regs, function (_, reg) {
                reg.test(s) && matches++;
            });

            return regsl == matches && (!node.NoMenu || search);
        });

        var searchResult = result.slice(0);

        $.each(searchResult, function (_, o) {
            addParentsTo(result, o, menuNodes);
        });

        var rootNodes = $.grep(result, function (o) { return !o.ParentId; });

        var getChildren = function (node, nodeLevel) {
            return $.grep(result, function (o) { return o.ParentId == node.Id; });
        };

        function makeHeader(info) {
            var isNodeSelected = info.NodeItem.IsNodeSelected;
            var collapsed = !search && !isNodeSelected && info.NodeItem.Collapsed;
            return {
                Item: info.NodeItem,
                Collapsed: collapsed,
                IgnorePersistence: search || isNodeSelected
            };
        }

        return utils.gridModelBuilder(this, g, rootNodes, { key: "Id", getChildren: getChildren, defaultKeySort: 1, forceSort: 1, makeHeader: makeHeader });
    }
    
    return function (gp) {
        var g = utils.getGridParams(gp);
        var url = this.tag.ItemsUrl;
        var storageKey = awe.ppk + "_menuNodes";

        if (menuNodes) {
            return buildMenuGridModel(g);
        }
        else if (sessionStorage && sessionStorage[storageKey]) {
            menuNodes = JSON.parse(sessionStorage[storageKey]);
            return buildMenuGridModel(g);
        }
        else {
            return $.get(url).then(function (items) {
                menuNodes = items;
                sessionStorage[storageKey] = JSON.stringify(items);
                return buildMenuGridModel(g);
            });
        }
    };
}

function menutree(o) {
    o.alt = 0; // no alt row css
    var api = o.api;
    // render row
    api.itmf = function (opt) {
        var content = '';
        var itm = opt.itm;
        if (opt.ceb) content += api.ceb();
        content += itm.Name;

        if (opt.ceb) {
            opt.clss += ' mnitm awe-ceb';
        } else {
            opt.clss += ' mnitm ';
        }

        var attr = opt.attr;
        attr += ' class="' + opt.clss + '"';
        var style = opt.style || '';

        if (opt.ind) {
            style += 'padding-left:' + opt.ind / 2 + 'em;';
        }

        style && (attr += ' style="' + style + '"');

        return itm.Url ?
            '<a href="' + itm.Url + '" ' + attr + ' >' + content + '</a>' :
            '<div ' + attr + '>' + content + '</div>';
    };
}