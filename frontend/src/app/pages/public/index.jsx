import React from 'react';                                {/*<div className={ styles['logo-wrapper'] }>*/}
                                    {/*<Logo />*/}
                                {/*</div>*/}
import PropTypes from 'prop-types';
import { Route, Switch, Redirect } from 'react-router-dom';
import { Container, Row, Col } from 'reactstrap';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { push } from 'connected-react-router';

import LoginPage from 'app/pages/public/login/login';
import LandingPage from "app/pages/public/landing/landing";
import { Logo } from 'app/components/logo';

import styles from './index.scss';

class PublicPages extends React.Component {
    constructor(props) {
        super(props);

        if (props.session.token) {
            props.actions.router.push('/servers');
        }
    }

    render() {
        return (
            <div className={ styles['public-pages'] }>
                <Container fluid>
                    <Row>
                        <Col
                            xs="12"
                            sm={{ size: 12, offset: 0 }}
                            md={{ size: 8, offset: 2 }}
                            lg={{ size: 12, offset: 0 }}
                        >
                            <React.Fragment>
                                <Switch>
                                    <Route exact path="/public/login" component={ LoginPage } />
									<Route exact path="/public/landing" component={ LandingPage } />
                                    <Redirect to="/public/landing" />
                                </Switch>
                            </React.Fragment>
                        </Col>
                    </Row>
                </Container>
            </div>
        );
    }
}

const mapStateToProps = (state) => ({
    session: state.session,
});

const mapDispatchToProps = (dispatch) => ({
    actions: {
        router: {
            push: bindActionCreators(push, dispatch),
        },
    },
});

PublicPages.propTypes = {
    session: PropTypes.shape({
        token: PropTypes.string,
    }).isRequired,
    actions: PropTypes.shape({
        router: PropTypes.shape({
            push: PropTypes.func,
        }),
    }).isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(PublicPages);
