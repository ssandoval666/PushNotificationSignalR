function notification(m) {
    console.log("SSSSS");
    const payload = JSON.parse(m);

    if (window.Notification && Notification.permission === 'granted') {
        const options = {
            body: payload.body
        };
        swRegistration.showNotification(payload.message, options);
    }
    // If the user hasn't told whether he wants to be notified or not
    // Note: because of Chrome, we cannot be sure the permission property
    // is set, therefore it's unsafe to check for the "default" value.
    else if (window.Notification && Notification.permission !== 'denied') {
        Notification.requestPermission(status => {
            if (status === 'granted') {
                const options = {
                    body: payload.body
                };
                swRegistration.showNotification(payload.message, options);
            } else {
                alert('You denied or dismissed permissions to notifications.');
            }
        });
    } else {
        // If the user refuses to get notified
        alert(
            'You denied permissions to notifications. ' +
            'Please go to your browser or phone setting to allow notifications.'
        );
    }
}

async function ExistingSubscription() {
    var Rta = false;

    if (window.Notification && Notification.permission === 'granted') {
        const existingSubscription = await swRegistration.pushManager.getSubscription();

        if (existingSubscription != null) {
            await worker.pushManager.subscribe({
                userVisibleOnly: true,
                applicationServerKey: applicationServerPublicKey
            });
        }

        Rta = true;
    }


    return Rta;
}

async function subscribe() {
    
    var Rta = false;

    Notification.requestPermission(status => {
        if (status === 'granted') {
            Rta = true;
        }
    });

    if (Rta) {
        await worker.pushManager.subscribe({
            userVisibleOnly: true,
            applicationServerKey: applicationServerPublicKey
        });
    }
}