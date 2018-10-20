import React from 'react';
import { Alert } from 'reactstrap';

import ChartPage from '../chart/chart-page'
import NotificationPage from '../notification/notification-page'

class DashboardPage extends React.Component {
    static renderContent() {
        return (
            <div>
                <NotificationPage />
                <ChartPage />
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
