function notification(m)
{
    const payload =JSON.parse(m);

    

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
                //notification();
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

async function subscribe()
{
    const existingSubscription = await swRegistration.pushManager.getSubscription();

    if (!existingSubscription) {
        await worker.pushManager.subscribe({
            userVisibleOnly: true,
            applicationServerKey: applicationServerPublicKey
        });
    }

    return true;
}