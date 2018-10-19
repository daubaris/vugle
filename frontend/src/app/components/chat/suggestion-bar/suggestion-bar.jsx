import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import chatActions from './../redux/actions';
import SuggestionsBubble from '../suggestions-bubble/suggestions-bubble';

import styles from './suggestions-bar.scss';

class SuggestionBar extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            suggestions: [{
                id: 1,
                title: 'test'
            },{
                id: 2,
                title: 'test'
            },{
                id: 3,
                title: 'test'
            },{
                id: 4,
                title: 'test'
            }]
        };

        this.onClick = this.onClick.bind(this);
    }


    onClick(suggestion) {
        const {
            actions,
        } = this.props;

        actions.chat.addUserMessage(suggestion);
    }

    render() {
		const {
            suggestions,
		} = this.state;

		return (
			<div className={ styles['suggestion-bar'] }>
				{ suggestions.map(suggestion => (
					<SuggestionsBubble
						key={ suggestion.id }
                        suggestion={ suggestion }
						onClick={ this.onClick }
					/>
				))}
			</div>
		);
	}
}

const mapStateToProps = (state) => ({
    chat: state.chat,
});

const mapDispatchToProps = (dispatch) => ({
    actions: {
        chat: bindActionCreators(chatActions, dispatch)
    },
});

export default connect(mapStateToProps, mapDispatchToProps)(SuggestionBar);
