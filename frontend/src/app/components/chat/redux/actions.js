import { createAction } from 'redux-actions';

export const ADD_MESSAGE = 'CHAT__ADD_MESSAGE';
export const BEFORE_ADD_BOT_MESSAGE = 'CHAT__BEFORE_ADD_BOT_MESSAGE';
export const AFTER_ADD_BOT_MESSAGE = 'CHAT__AFTER_ADD_BOT_MESSAGE';

const actions = {
    addMessage: createAction(ADD_MESSAGE),
    beforeAddBotMessage: createAction(BEFORE_ADD_BOT_MESSAGE),
    afterAddBotMessage: createAction(AFTER_ADD_BOT_MESSAGE),
};

function getTimeout(suggestionsLength, index) {
    const leftMessagesCount = suggestionsLength - (index + 1);

    if (suggestionsLength >= 3 && leftMessagesCount === 0) {
        return 0;
    }

    return Math.random() * 5000;
}

function sleep(milliseconds) {
    return new Promise(resolve => setTimeout(resolve, milliseconds))
}

const pushMessages = (suggestions, counter, dispatch) => {
    const suggestion = suggestions[counter];

    return new Promise((resolve, reject) => {
        if (suggestion) {
            dispatch(actions.beforeAddBotMessage());
            sleep(Math.random() * 1000)
                .then(() => {
                    dispatch(addBotMessage({ title: suggestion.title }));
                    pushMessages(suggestions, counter + 1, dispatch);
                });
        } else  if (!suggestion) {
            return resolve();
        }
    });
}

const addUserMessage = (suggestion) => (dispatch) => {
    const message = {
        type: 'user',
        message: suggestion.title,
    };

    dispatch(actions.addMessage(message));

    sleep(300)
        .then(() => {
            pushMessages(suggestion.responses, 0, dispatch);
        });
};

const addBotMessage = (suggestion) => (dispatch) => {
    const message = {
        type: 'bot',
        id: new Date().getTime(),
        message: suggestion.title,
    };

    dispatch(actions.addMessage(message));
};

export default {
    addUserMessage,
    addBotMessage,
    beforeAddBotMessage: actions.beforeAddBotMessage
};
