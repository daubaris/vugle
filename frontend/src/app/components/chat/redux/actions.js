import { createAction } from 'redux-actions';

export const ADD_MESSAGE = 'CHAT__ADD_MESSAGE';
export const BEFORE_ADD_BOT_MESSAGE = 'CHAT__BEFORE_ADD_BOT_MESSAGE';
export const AFTER_ADD_BOT_MESSAGE = 'CHAT__AFTER_ADD_BOT_MESSAGE';
export const SET_BOT_RESPONDING = 'CHAT__SET_BOT_RESPONDING';

const actions = {
    addMessage: createAction(ADD_MESSAGE),
    beforeAddBotMessage: createAction(BEFORE_ADD_BOT_MESSAGE),
    afterAddBotMessage: createAction(AFTER_ADD_BOT_MESSAGE),
    setBotResponding: createAction(SET_BOT_RESPONDING),
};

function getTimeout() {
    return Math.random() * 1000;
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function sleep(milliseconds) {
    return new Promise(resolve => setTimeout(resolve, milliseconds))
}

const pushMessages = (suggestions, counter, dispatch) => {
    const suggestion = suggestions[counter];

    return new Promise((resolve, reject) => {
        if (suggestion) {
            if (suggestion.random) {
                if (Math.random() > suggestion.random) {
                    dispatch(actions.beforeAddBotMessage());
                    document.getElementById('chart-area').scrollTop = document.getElementById('chart-area').clientHeight + 200;
                    sleep(Math.random() * getTimeout())
                        .then(() => {
                            dispatch(addBotMessage({ title: suggestion.title }));
                            pushMessages(suggestions, counter + 1, dispatch);
                            document.getElementById('chart-area').scrollTop = document.getElementById('chart-area').clientHeight + 200;
                        });
                } else {
                    pushMessages(suggestions, counter + 1, dispatch);
                }
            } else {
                dispatch(actions.beforeAddBotMessage());
                document.getElementById('chart-area').scrollTop = document.getElementById('chart-area').clientHeight + 200;
                sleep(Math.random() * getTimeout())
                    .then(() => {
                        dispatch(addBotMessage({ title: suggestion.title }));
                        pushMessages(suggestions, counter + 1, dispatch);
                        document.getElementById('chart-area').scrollTop = document.getElementById('chart-area').clientHeight + 200;
                    });
            }
        } else  if (!suggestion) {
            dispatch(actions.setBotResponding(false));
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
    dispatch(actions.setBotResponding(true));
    document.getElementById('chart-area').scrollTop = document.getElementById('chart-area').clientHeight + 200;

    sleep(300)
        .then(() => {
            pushMessages(suggestion.responses, 0, dispatch);
        });
};

const addBotMessage = (suggestion) => (dispatch) => {
    const messageTitle = Array.isArray(suggestion.title)
        ? suggestion.title[getRandomInt(0, suggestion.title.length - 1)]
        : suggestion.title;

    const message = {
        type: 'bot',
        id: new Date().getTime(),
        message: messageTitle,
    };

    dispatch(actions.addMessage(message));
};

export default {
    addUserMessage,
    addBotMessage,
    beforeAddBotMessage: actions.beforeAddBotMessage,
    setBotResponding: actions.setBotResponding,
};
