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

    return Math.random() * 1000;
}

const addUserMessage = (suggestion) => (dispatch) => {
    const message = {
        type: 'user',
        message: suggestion.title,
    };

    dispatch(actions.addMessage(message));

    const suggestionsLength = suggestion.responses.length;
    let timeout = 0;

    setTimeout(() => {
        suggestion.responses.forEach((response, index) => {
            timeout = getTimeout(suggestionsLength, index);

            if (!response.random) {
                dispatch(addBotMessage({ title: response.title }), timeout);
            } else {
                const showMessage = Math.random() > response.random;
                if (showMessage) {
                    dispatch(addBotMessage({ title: response.title }), timeout);
                }
            }
        });
    }, 300);
};

const addBotMessage = (suggestion, timeout = 0) => (dispatch) => {
    const message = {
        type: 'bot',
        id: new Date().getTime(),
        message: suggestion.title,
    };

    if (!timeout) {
        dispatch(actions.addMessage(message));
    } else {
        dispatch(actions.beforeAddBotMessage());

        setTimeout(() => {
            dispatch(actions.afterAddBotMessage());
            dispatch(actions.addMessage(message));
        },timeout);
    }
};

export default {
    addUserMessage,
    addBotMessage,
};
