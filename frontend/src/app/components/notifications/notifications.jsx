import React from 'react';

import pusher from 'app/services/pusher';

import Notification from './notification';

class Notifications extends React.Component {
    constructor(props) {
        super(props);

        this.onGetNotification = this.onGetNotification.bind(this);

        this.state = {
            notifications: [],
        };
    }

    componentDidMount() {
        const channel = pusher.subscribe('vugle-notifications');

        channel.bind('new-notification', this.onGetNotification);
    }

    onGetNotification(notification) {
        const {
            notifications,
        } = this.state;

        this.setState({
            notifications: [
                ...notifications,
                notification,
            ],
        });
    }

    render() {
        const {
            notifications,
        } = this.state;

        return (
            <div>
                { notifications.map(notification => (
                    <Notification
                        key={ notification.id }
                        notification={ notification }
                    />
                )) }
            </div>
        );
    }
}

export default Notifications;
