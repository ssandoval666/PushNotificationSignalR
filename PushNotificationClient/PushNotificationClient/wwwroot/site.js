﻿let swRegistration = null;


window.addEventListener("message", (event) => {
    console.log(event);
    console.log(JSON.stringify(event));
}, false);

window.Connection = {
    Initialize: function (interop) {

        handler = function () {
            interop.invokeMethodAsync("Connection.StatusChanged", navigator.onLine);
        }

        window.addEventListener("online", handler);
        window.addEventListener("offline", handler);

        handler(navigator.onLine);
    },
    Dispose: function () {

        if (handler != null) {

            window.removeEventListener("online", handler);
            window.removeEventListener("offline", handler);
        }
    }
};

window.addEventListener('beforeinstallprompt', function (e) {
    e.preventDefault();
    // Stash the event so it can be triggered later.
    // where you store it is up to you
    window.PWADeferredPrompt = e;
    // Notify C# Code that it can show an alert 
    // MyBlazorInstallMethod must be [JSInvokable]
    DotNet.invokeMethodAsync("MyBlazorAssembly", "MyBlazorInstallMethod");
});

window.addEventListener('appinstalled', () => {
    // Hide the app-provided install promotion
    hideInstallPromotion();
    // Clear the deferredPrompt so it can be garbage collected
    deferredPrompt = null;
    // Optionally, send analytics event to indicate successful install
    console.log('PWA was installed');
});

window.BlazorPWA = {
    installPWA: function () {
        if (window.PWADeferredPrompt) {
            // Use the stashed event to continue the install process
            window.PWADeferredPrompt.prompt();
            window.PWADeferredPrompt.userChoice
                .then(function (choiceResult) {
                    window.PWADeferredPrompt = null;
                });
        }
    }
};


window.DisplayMode = {
    getPWADisplayMode: function () {
        const isStandalone = window.matchMedia('(display-mode: standalone)').matches;
        if (document.referrer.startsWith('android-app://')) {
            console.log('twa');
            return 'twa';
        } else if (navigator.standalone || isStandalone) {
            console.log('standalone');
            return 'standalone';
        }

        console.log('browser');
        return 'browser';
    }
};

window.matchMedia('(display-mode: standalone)').addEventListener('change', (evt) => {
    let displayMode = 'browser';
    if (evt.matches) {
        displayMode = 'standalone';
    }
    // Log display mode change to analytics
    console.log('DISPLAY_MODE_CHANGED', displayMode);
});
