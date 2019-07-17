function documentReady() {
    var root = document.root;

    var menu = getSideMenu({ id: 'Menu', src: 'msearch', keyupf: srckup });
    menu.init();

    layPage();
    $(window).on('resize', layPage);

    handleAnchors();

    $('#btnLogo').click(function (e) {
        if ($(window).width() < 1050) {
            e.preventDefault();
            $('#btnMenuToggle').click();
        }
    });

    $('#btnMenuToggle').click(function () {
        MenuToggle($('#demoMenu').is(':visible'));
    });

    parseCode();

    handleTabs();

    $('#chTheme').change(function () {
        var theme = $('#chTheme').val();
        $('#aweStyle').attr('href', root + "Content/themes/" + theme + "/AwesomeMvc.css?v=" + document.ver);
        $('body').attr('class', theme);
        Cookies && Cookies.set('awedemset2', theme, { expires: 30 });
    });

    regGridSync();
    $(document).ajaxComplete(regGridSync);

    $(document).on('aweload', 'table.awe-ajaxlist', wrapLists);

    var lastw = 0;
    function layPage() {
        var ww = $(window).width();

        $("#main").css("min-height", ($(window).height() - 120) + "px");
        $('#maincont').css("min-height", $(window).height() - ($('#header').outerHeight() + 110));
        if (lastw != ww)
            MenuToggle(ww < 1050);
        lastw = ww;
        menu.setHeight();
    }

    var stmo;
    function srckup() {
    }
}

function parseCode() {
    $('pre').addClass('prettyprint');

    // show code 
    $('.code').each(function (i, el) {
        var c = $(el);
        if (!c.data('h')) {
            c.data('h', 1);

            var scbtn = $('<span class="shcode">show code</span>')
                .click(function() {
                    var btn = $(this);
                    btn.toggleClass("hideCode showCode");

                    var div = $(this).parent().next();

                    if (btn.hasClass("hideCode")) {
                        btn.html("hide code");
                        div.fadeIn();
                    } else {
                        btn.html("show code");
                        div.fadeOut();
                    }
                });

            var wrp = $('<div/>').append(scbtn);
            c.wrap('<div/>')
                .parent()
                .hide()
                .before(wrp);
        }
    });
}

var tabid = 0;
function handleTabs() {
    $('.tabs').each(function (i, item) {
        var tabs = $(item);
        if (!tabs.data('tabsh')) {
            tabs.data('tabsh', 1);

            var id = 'mytab' + tabid++;
            tabs.attr('id', id).addClass('awe-tabs');
            tabs.children().wrapAll('<div class="awe-tabscontent"/>').addClass('awe-tab');

            $('<div class="awe-tabsbar"></div>').prependTo(tabs);
            awe.tabs({ i: id });
        }
    });
}

function handleAnchors() {
    var anchor = location.hash.replace('#', '').replace(/\(|\)|:|\.|\;|\\|\/|\?|,/g, '');
    $('h3,h2').each(function (_, e) {
        var a = $(e);
        if (!a.data('ah')) {
            a.data('ah', 1);
            var name = a.data('name');
            var url = a.data('u') || '';
            if (!name) name = $.trim(a.html()).replace(/ /g, '-').replace(/\(|\)|:|\.|\;|\\|\/|\?|,/g, '');
            name = name.replace('&lt', '').replace('&gt', '');
            a.append("<a class='anchor' name='" + name + "' href='" + url + "#" + name + "' tabIndex='-1'>&nbsp;<i class='ico-link'></i></a>");

            if (name == anchor) {
                location.href = "#" + name;
                awe.flash(a);
            }
        }
    });
}

// wrap ajaxlists for horizontal scrolling on small screens
function wrapLists() {
    $('table.awe-ajaxlist:not([wrapped])').each(function () {
        var columns = $(this).find('thead th').length;
        var mw = $(this).data('mw');
        if (columns || mw) {
            mw = mw || columns * 120;

            $(this).wrap('<div style="width:100%; overflow:auto;"></div>')
                .wrap('<div style="min-width:' + mw + 'px;padding-bottom:2px;"></div>')
                .attr('wrapped', 'wrapped');
        }
    });
}

function MenuToggle(hide) {
    var page = $('#demoPage').show();
    var menu = $('#demoMenu').css('width', '').css('position', '');

    if (hide) {
        menu.hide();
        page.css('margin-left', "0");
        $('#btnMenuToggle').show().removeClass('on');
        $('body').trigger('domlay');
    } else {
        menu.show();

        page.css('margin-left', "14.5em");

        if (page.width() < 200) {
            page.hide();
            menu.css('width', '100%');
            menu.css('position', 'static');
        }

        $('#btnMenuToggle').addClass('on');

        $('body').trigger('domlay');
    }
}

function gitCaption(item) {
    return '<img class="cthumb" src="' + item.avatar + '&s=40" />' + item.c;
}

function gitItem(item) {
    var res = "<div class='content'>" + '<div class="title">' + item.c + '<img class="thumb" src="' + item.avatar + '&s=40" />' + '</div>';
    if (item.desc) res += '<p class="desc">' + item.desc + '</p>';
    res += '</div>';
    return res;
}

function multiImgCaption(o) {
    return '<img class="cthumb" src="' + o.url + '" />' + o.c;
}

function gitRepoSearch(o, info) {
    var term = info.term;
    var c = info.cache;
    c.termsUsed = c.termsUsed || {};
    c.nrterms = c.nrterms || []; // no result terms

    if (c.termsUsed[term]) return [];
    c.termsUsed[term] = 1;

    var nores = 0;
    // don't search terms that contain nrterms
    $.each(c.nrterms, function (i, val) {
        if (term.indexOf(val) >= 0) {
            nores = 1;
            return false;
        }
    });

    if (nores) {
        return [];
    }

    return $.get('https://api.github.com/search/repositories', { q: term })
        .then(function (data) {
            if (!data || !data.items.length) {
                c.nrterms.push(term);
            }

            return $.map(data.items, function (item) { return { k: item.id, c: item.full_name, avatar: item.owner.avatar_url, desc: item.description }; });
        })
        .fail(function () { c.termsUsed[term] = 0; });
}

function getFormattedTime() {
    var d = new Date();
    return ('0' + d.getHours()).slice(-2) + ":" + ('0' + d.getMinutes()).slice(-2) + ":" + ('0' + d.getSeconds()).slice(-2);
}

var downloadLinks = [
        { k: "https://www.aspnetawesome.com/Download/MvcCoreDemoApp", c: "Main Demo - ASP.net Core (this demo)" },
        { k: "https://www.aspnetawesome.com/Download/MvcDemoApp", c: "Main Demo - MVC 5 (this demo)" },
        { k: "https://www.aspnetawesome.com/Download/MinSetupCoreDemo", c: "Min Setup Demo - ASP.net Core (Template Project)" },
        { k: "https://www.aspnetawesome.com/Download/MvcMinSetupDemo", c: "Min Setup Demo - MVC 5 (Template Project)" },
        { k: "https://www.aspnetawesome.com/Download/RazorPagesDemo", c: "Razor Pages Demo" },
        { k: "https://www.aspnetawesome.com/Download/MvcTrial", c: "Trial version binaries for ASP.net Core, MVC 5/4/3" },
        { k: "https://www.aspnetawesome.com/Download/SimpleDemo", c: "Simple Demo MVC5" },
        { k: "https://www.aspnetawesome.com/Download/VBnetDemo", c: "VB.net Demo" },
        { k: "https://www.aspnetawesome.com/Download/ProDinner", c: "ProDinner (uses EF, N-Tier, etc.)" },
        { k: "", c: "", cs: "o-litm", nv: 1 },
        { k: "", c: "See also:", cs: "citm", nv: 1 },
        { k: "https://prodinner.aspnetawesome.com", c: "ProDinner live" },
        { k: "https://demowf.aspnetawesome.com", c: "Main Demo for ASP.net Web-Forms" }
];

var themes = $.map(["wui", "mui", "bts", "met", "gui", "gui3", "start", "black-cab"], function (v) { return { k: v, c: v } });

function loadWhenSeen(el, url, indx, callback) {
    var started = 0;
    if (!loadIfVis()) {
        $(window).on('scroll resize', loadIfVis);
    }

    function loadIfVis() {
        if (el.offset().top + el.outerHeight() < $(window).height() + $(window).scrollTop() + 300) {
            if (started) return 1;
            started = 1;

            $(window).off('scroll resize', loadIfVis);
            $.get(url, { v: indx }, function (res) {
                callback(res);
            });

            return 1;
        }
    }
}

// textarea autocomplete 
function getCaretPos(ctrl) {
    var caretPos = 0;
    if (document.selection) {
        ctrl.focus();
        var sel = document.selection.createRange();
        sel.moveStart('character', -ctrl.value.length);
        caretPos = sel.text.length;
    }
    else if (ctrl.selectionStart || ctrl.selectionStart == '0') {
        caretPos = ctrl.selectionStart;
    }
    return caretPos;
}

function getWordAtPos(s, pos) {
    var preText = s.substring(0, pos);
    if (preText.indexOf(" ") > 0 || preText.indexOf("\n") > 0) {
        var words = preText.split(" ");
        words = words[words.length - 1].split("\n");
        return words[words.length - 1]; // return last word
    }
    else {
        return preText;
    }
}

function getCaretWord(el) {
    var pos = getCaretPos(el);
    return getWordAtPos(el.value, pos);
}

function replaceInTexarea(t, text, word) {
    if (t.setSelectionRange) {
        var sS = t.selectionStart - word.length;
        var sE = t.selectionEnd;
        t.value = t.value.substring(0, sS) + text + t.value.substr(sE);
        t.setSelectionRange(sS + text.length, sS + text.length);
        t.focus();
    }
    else if (t.createTextRange) {
        document.selection.createRange().text = text;
    }
}
