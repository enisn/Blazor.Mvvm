window.setTitle = (title) => {
    document.title = title;
};

window.loadFile = (filename, filetype) => {
    if (filetype == "js") { //if filename is a external JavaScript file
        let scripts = document.scripts;
        for (let i = 0; i < scripts.length; i++) {
            if (scripts[i].src.includes(filename))
                return;
        }

        let fileref = document.createElement('script');
        fileref.setAttribute("type", "text/javascript");
        fileref.setAttribute("src", filename);
        document.getElementsByTagName("body")[0].appendChild(fileref);

    } else if (filetype == "css") { //if filename is an external CSS file
        let ss = document.styleSheets;
        for (let i = 0; i < ss.length; i++) {
            if (ss[i].href.includes(filename))
                return;
        }

        let fileref = document.createElement("link");
        fileref.setAttribute("rel", "stylesheet");
        fileref.setAttribute("type", "text/css");
        fileref.setAttribute("href", filename);
        document.getElementsByTagName("head")[0].appendChild(fileref);
    }
    else if (filetype == "favicon") {
        let fileref = document.createElement("link");
        fileref.setAttribute("rel", "shortcut icon");
        fileref.setAttribute("href", filename);
        document.getElementsByTagName("head")[0].appendChild(fileref);
    }
};

window.switchToTenantAssetsFromCs = (tenant) => {
    $("[href*='assets']").each(function (index) {
        $(this).attr('href', $(this).attr('href').replace('assets/', 'assets_' + tenant + '/'));
    });
};

window.appendFromCs = (selector, rawHtml) => {
    $(selector).append(rawHtml);
};

window.setAttributeFromCs = (selector, attributeName, attributeValue) => {
    $(selector).attr(attributeName, attributeValue);
}