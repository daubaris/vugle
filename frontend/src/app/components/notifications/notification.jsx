import React from 'react';
import PropTypes from 'prop-types';

class Notification extends React.PureComponent {
    render() {
        const {
            notification,
        } = this.props;

        return (
            <div>
                <h1>{ notification.title }</h1>
                <p>{ notification.description }</p>
            </div>
        );
    }
}

Notification.propType = {
    notification: PropTypes.shape({
        id: PropTypes.number.isRequired,
        title: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired,
        url: PropTypes.string,
    }),
};

export default Notification;
const demo = {
    "id": 23,
    "title": "Hack$Vilnius",
    "description": "Ka vakare?",
    "url": "www.vilnius.lt"
};
