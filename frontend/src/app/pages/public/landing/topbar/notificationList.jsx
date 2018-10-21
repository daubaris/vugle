import React from 'react';
import { Spinner, Alert } from 'evergreen-ui';
import restService from 'app/services/api';
import moment from 'moment';

class NotificationList extends React.Component {
    constructor(props) {
        super(props);

        this.loadNotifications = this.loadNotifications.bind(this);

        this.state = {
            notifications: []
        }
    }

    componentDidMount() {
        this.loadNotifications();
    }

    loadNotifications() {
        return restService.get('api/pusher/all').then(response => {
            if (response) {
                this.setState(this.state.notifications = response);
            }
        })
    }

    render() {
        return (
            <div>
                {!this.state.notifications && <Spinner />}
                {!!this.state.notifications && this.state.notifications.length === 0 && <div>Žinučių nėra.</div>}
                {this.state.notifications.length > 0 && 
                this.state.notifications.map(notification => (
                    <Alert intent={ notification.type !== "info" ? notification.type : "none" }
                           title={ notification.title }
                           marginBottom={ 16 }
                           key={ notification.id }>
                        Data: { moment(notification.date).format('YYYY-MM-DD HH:mm') } <br/>
                        { notification.description }
                    </Alert>
                ))
                }
            </div>
        );
    }
}

export default NotificationList;
