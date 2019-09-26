window.registerInputsFromCs = (className) => {
    $('input').each(function () {
        if ($(this).val())
            $(this).removeClass(className);
        else
            $(this).addClass(className);
    });

    $('input').on("change", function () {
        var val = $(this).val();
        if (val)
            $(this).removeClass(className);
        else
            $(this).addClass(className);
    });
};

window.initStrengthInputFromCs = () => {
    $('*[data-plugin="strength"]').strength(PluginJqueryStrength.default.getDefaults());
};

window.writeCookieFromCs = (name, value, exDays, path, domain) => {
    if (path == null)
        path = "/";
    var d = new Date();
    d.setTime(d.getTime() + (exDays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = name + "=" + value + ";" + expires + ";path=" + path + ";domain=" + domain;
};

window.readCookieFromCs = (cookieName) => {
    var name = cookieName + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
};

window.clickFromCs = (selector) => {
    $(selector).click();
};