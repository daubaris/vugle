import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import pusher from 'app/services/pusher';

import { SuggestionBar } from './suggestion-bar';
import Messages from './messages/messages';
import chatActions from './redux/actions';
import { TypingMessage } from "./typing-message";

import styles from './chat.scss';


function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

// Maps message array and adds random emoji to the end of the sentence
export function randomEmojiGenerator(message) {
    const emojipedia = [' 🤟', ' ✌️', ' 🖖', ' 🙂', ' 👏', ' 💪', ' 😎', '', '', '', ''];

    if(typeof message === 'object'){
        return message.map(item => (
            item + emojipedia[getRandomInt(0,10)]
        ));
    }

    else return message + emojipedia[getRandomInt(0,10)];
}

class Chat extends React.Component {
    constructor(props) {
        super(props);

        this.onGetPoll = this.onGetPoll.bind(this);
    }

    componentDidMount() {
        const {
            actions,
        } = this.props;

        const channel = pusher.subscribe('vugle-notifications');

        channel.bind('new-poll', this.onGetPoll);

        actions.chat.beforeAddBotMessage();
        setTimeout(() => {
            const titles = randomEmojiGenerator(['Sveiki!', 'Labas!', 'Labas, aš Vugle!']);
            actions.chat.addBotMessage({ title: titles});
            setTimeout(() => {
                actions.chat.beforeAddBotMessage();
                setTimeout(() => {
                    actions.chat.addBotMessage({ title: 'Kaip galetume Jums padeti?'});
                    actions.chat.setBotResponding(false);
                }, 500);
            }, 300)
        }, 750);
    }

    onGetPoll(pollId) {
        const {
            actions,
        } = this.props;

        actions.chat.addPollMessage(pollId);
    }

    render() {
        const {
            chat: {
                messages,
                waitingForBotResponse,
                botResponding,
            },
        } = this.props;

        return (
            <div className={ styles['chat'] }>
                <div className={ styles['char-area'] } id="chart-area">
                    { messages.map(message => (
                        <Messages
                            key={ message.id }
                            type={ message.type }
                            message={ message.message }
                            allMessage={ message }
                        />
                    ))}
                    { waitingForBotResponse && <TypingMessage/> }
                </div>
                <SuggestionBar loading={ botResponding } />
            </div>
        );
    }
}

const mapStateToProps = (state) => ({
    chat: state.chat,
});

const mapDispatchToProps = (dispatch) => ({
    actions: {
        chat: bindActionCreators(chatActions, dispatch),
    },
});

export default connect(mapStateToProps, mapDispatchToProps)(Chat);
