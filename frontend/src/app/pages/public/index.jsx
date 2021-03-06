import React from 'react';
import PropTypes from 'prop-types';
import {Route, Switch, Redirect} from 'react-router-dom';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import {push} from 'connected-react-router';

import LoginPage from 'app/pages/public/login/login';
import LandingPage from 'app/pages/public/landing/landing';
import {Logo} from 'app/components/logo';

class PublicPages extends React.Component {
	constructor(props) {
		super(props);

		if (props.session.token) {
			props.actions.router.push('/admin/dashboard');
		}
	}

	render() {
		return (
			<Switch>
				<Route exact path="/public" component={LandingPage}/>
				<Route exact path="/public/login" component={LoginPage}/>
				<Redirect to="/public"/>
			</Switch>
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
