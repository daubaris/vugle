import React from 'react';
import { Alert } from 'reactstrap';

import NotificationPage from '../notification/notification-page';
import PollResultsPage from '../poll/poll-results-page';

class DashboardPage extends React.Component {
    static renderContent() {
        return (
            <div>
                <NotificationPage />
                <PollResultsPage />
            </div>
        );
    }

    constructor(props) {
        super(props);

        this.state = {
            loading: true,
            error: null,
        };
    }

    render() {
        const {
            loading,
            error,
        } = this.state;

        // TODO show loader

        return (
            <div>
                { error && <Alert color="danger">{ error }</Alert>}

                { DashboardPage.renderContent() }
            </div>
        );
    }
}

export default DashboardPage;
