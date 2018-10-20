import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { push } from 'connected-react-router';
import { SubmissionError } from 'redux-form';
import { Container, Row, Col, Card, CardBody } from 'reactstrap';

import sessionActions from 'app/pages/private/session/redux/actions';
import LoginForm from './form';

import styles from './login.scss';
import restService from 'app/services/api';

class LoginPage extends React.PureComponent {
    constructor(props) {
        super(props);

        this.onSubmitLogin = this.onSubmitLogin.bind(this);
    }

    parseLoginResponse(response) { 
    }

    onSubmitLogin({ username, password }) {
        const {
            actions,
        } = this.props;
        
        return restService.post('api/user', {
            "username": username,
            "password": password,
        }).then(response => { 
            if (response.status >= 200 && response.status < 300) {
                actions.session.setToken('___SUPER_SECRET_TOKEN___');
                actions.router.push('/admin/dashboard');
            } else {
                throw new SubmissionError({
                    _error: 'Invalid credentials',
                });
            }
        }).catch(error => {
            if (error.response && error.response.status === 401) {
                throw new SubmissionError({
                    _error: 'Invalid credentials',
                });
            } else {
                throw new SubmissionError({
                    _error: 'Request error',
                });
            }
        });
    }

    render() {
        return (
            <Container className={ styles['login'] }>
                <Row>
                    <Col lg={{ size: 6, offset: 3 }}>
                        <Card>
                            <CardBody>
                                <LoginForm
                                    onSubmit={ this.onSubmitLogin }
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

LoginPage.propTypes = {
    actions: PropTypes.shape({
        session: PropTypes.shape({
            getToken: PropTypes.func,
        }),
        router: PropTypes.shape({
            push: PropTypes.func,
        }),
    }).isRequired,
};

export default connect(null, mapDispatchToProps)(LoginPage);
