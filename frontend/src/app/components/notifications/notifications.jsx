import React from 'react';

import pusher from 'app/services/pusher';

import { toaster } from 'evergreen-ui';

class Notifications extends React.Component {
    constructor(props) {
        super(props);

        this.onGetNotification = this.onGetNotification.bind(this);
    }

    componentDidMount() {
        const channel = pusher.subscribe('vugle-notifications');

        channel.bind('new-notification', this.onGetNotification);
    }

    onGetNotification(notification) {
        this.showToaster(notification);
    }

    render() {
        return null;
    }

    showToaster(notification) {
        switch (notification.type) {
        case 'success':
            toaster.success(
                notification.title,
                {
                    description: notification.description,
                }
            );
            break;
        case 'warning':
            toaster.warning(
                notification.title,
                {
                    description: notification.description,
                }
            );
            break;
        case 'danger':
            toaster.danger(
                notification.title,
                {
                    description: notification.description,
                }
            );
            break;
        default:
            toaster.notify(
                notification.title,
                {
                    description: notification.description,
                }
            );
            break;
        }
    }
}

export default Notifications;
