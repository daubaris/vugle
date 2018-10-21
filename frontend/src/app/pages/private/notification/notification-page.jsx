import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { push } from 'connected-react-router';
import { Container, Row, Col, Card, CardBody } from 'reactstrap';

import sessionActions from 'app/pages/private/session/redux/actions';
import NotificationForm from './notification-form';
import restService from 'app/services/api';
import PollForm from '../poll/poll-form';

class NotificationPage extends React.PureComponent {
    constructor(props) {
        super(props);

        this.onSubmitNotification = this.onSubmitNotification.bind(this);
    }

    onSubmitNotification(values) {
        restService.post('https://vugle-be.azurewebsites.net/api/pusher', {
            "title": values.notificationTitle,
            "description": values.notificationText,
            "type": values.notificationType,
        })
    }

    onSubmitPoll(values) {
        restService.put('/Api/Poll', values);
    }

    render() {
        return (
            <Container>
                <Row>
                    <Col lg={{ size: 6 }}>
                        <Card>
                            <CardBody>
                                <NotificationForm
                                    onSubmit={ this.onSubmitNotification }
                                />
                            </CardBody>
                        </Card>
                    </Col>
                    <Col lg={{ size: 6 }}>
                        <Card>
                            <CardBody>
                                <PollForm
                                    onSubmit={ this.onSubmitPoll }
                                />
                            </CardBody>
                        </Card>
                    </Col>
                </Row>
            </Container>
        );
    }
}

const mapDispatchToProps = (dispatch) => ({
    actions: {
        session: bindActionCreators(sessionActions, dispatch),
        router: {
            push: bindActionCreators(push, dispatch),
        },
    },
});

NotificationPage.propTypes = {
    actions: PropTypes.shape({
        session: PropTypes.shape({
            getToken: PropTypes.func,
        }),
        router: PropTypes.shape({
            push: PropTypes.func,
        }),
    }).isRequired,
};

export default connect(null, mapDispatchToProps)(NotificationPage);
