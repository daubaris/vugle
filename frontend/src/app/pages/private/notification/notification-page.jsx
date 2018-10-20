import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { push } from 'connected-react-router';
import { Container, Row, Col, Card, CardBody } from 'reactstrap';
import restService from 'app/services/api';

import sessionActions from 'app/pages/private/session/redux/actions';
import NotificationForm from './notification-form';

class NotificationPage extends React.PureComponent {
    constructor(props) {
        super(props);

        this.onSubmitNotification = this.onSubmitNotification.bind(this);
    }

    onSubmitNotification(values) {
        console.log(values);
        restService.post('/sendNotification', values);
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
                                Poll form
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
