import React from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { SuggestionBar } from './suggestion-bar';
import Messages from './messages/messages';
import chatActions from './redux/actions';
import { TypingMessage } from "./typing-message";

import styles from './chat.scss';
import PollForm from './poll-form/poll-message-form';
import Poll from './poll-form/poll';

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
            const titles = ['Sveiki!', 'Labas!', 'Labas, aš Vugle!'];
            actions.chat.addBotMessage({ title: titles });
            setTimeout(() => {
                actions.chat.beforeAddBotMessage();
                setTimeout(() => {
                    actions.chat.addBotMessage({ title: 'Kaip galetume Jums padeti?' });
                    actions.chat.setBotResponding(false);
                }, 500);
            }, 300)
        }, 750);
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
                        />
                    ))}
                    { waitingForBotResponse && <TypingMessage/> }
                  
                    {/*<PollForm />*/}

                    <Poll
                        id={1}
                    />
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
