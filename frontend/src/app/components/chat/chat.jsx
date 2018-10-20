import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { SuggestionBar } from './suggestion-bar';
import Messages from './messages/messages';
import chatActions from './redux/actions';

import styles from './chat.scss';
import { TypingMessage } from "./typing-message";

class Chat extends React.Component {
    constructor(props) {
        super(props);

    }

    componentDidMount() {
        const {
            actions,
        } = this.props;

        actions.chat.beforeAddBotMessage();
        setTimeout(() => {
            actions.chat.addBotMessage({ title: 'Sveiki!' });
            setTimeout(() => {
                actions.chat.beforeAddBotMessage();
                setTimeout(() => {
                    actions.chat.addBotMessage({ title: 'Kaip galetume Jums padeti?' });
                }, 500);
            }, 300)
        }, 750);
    }

    render() {
        const {
            chat: {
                messages,
                waitingForBotResponse,
            },
        } = this.props;

        console.log(waitingForBotResponse, 'waitingForBotResponse');

        return (
            <div className={ styles['chat'] }>
                <div className={ styles['char-area'] }>
                    { messages.map(message => (
                        <Messages
                            key={ message.id }
                            type={ message.type }
                            message={ message.message }
                        />
                    ))}
                </div>
                { waitingForBotResponse && <TypingMessage/> }
                <SuggestionBar />
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

export default connect(mapStateToProps, mapDispatchToProps)(Chat);
