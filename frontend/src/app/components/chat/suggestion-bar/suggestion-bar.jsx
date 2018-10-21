import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import chatActions from './../redux/actions';
import SuggestionsBubble from '../suggestions-bubble/suggestions-bubble';

import styles from './suggestions-bar.scss';
import { randomEmojiGenerator } from '../chat';

class SuggestionBar extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            suggestions: [
                {
                    id: 1,
                    title: 'Noriu pranešti 🙋',
                    responses: [
                        {
                            title: randomEmojiGenerator('Puiku!'),
                            random: 0.5,
                        },
                        {
                            title: 'Ką norėtum pranešti?'
                        },
                    ]
                },
                {
                    id: 2,
                    title: 'Noriu sužinoti 📚',
                    responses: [
                        {
                            title: 'Ką norėtumet sužinoti?',
                        },
                    ]
                },
                {
                    id: 3,
                    title: 'Noriu pažinti 🤔',
                    responses: [
                        {
                            title: 'Ką norėtumet pažinti?',
                        },
                    ]
                },
                {
                    id: 4,
                    title: 'Noriu pramogauti 🤙',
                    responses: [
                        {
                            title: 'Kokios pramogos tave domina?',
                        },
                    ],
                },
            ]
        };

        this.onClick = this.onClick.bind(this);
    }

    componentDidMount() {
        const {
            actions,
        } = this.props;

        actions.chat.getSuggestions(0);
    }

    onClick(suggestion) {
        const {
            actions,
        } = this.props;

        actions.chat.addUserMessage(suggestion);
    }

    render() {
		const {
		    loading,
            chat,
        } = this.props;

		return (
			<div className={ styles['suggestion-bar'] }>
				{ chat.suggestions.suggestions
                    .sort((a, b) => {
                        return a.id - b.id;
                    })
                    .map(suggestion => (
					<SuggestionsBubble
						key={ suggestion.id }
                        suggestion={ suggestion }
						onClick={ this.onClick }
                        disabled={ loading }
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
