import { createAction } from 'redux-actions';
import restService from 'app/services/api';

export const ADD_MESSAGE = 'CHAT__ADD_MESSAGE';
export const BEFORE_ADD_BOT_MESSAGE = 'CHAT__BEFORE_ADD_BOT_MESSAGE';
export const AFTER_ADD_BOT_MESSAGE = 'CHAT__AFTER_ADD_BOT_MESSAGE';
export const SET_BOT_RESPONDING = 'CHAT__SET_BOT_RESPONDING';
export const ADD_POLL_MESSAGE = 'CHAT__ADD_POLL_MESSAGE';
export const BEFORE_GET_SUGGESTIONS = 'CHAT__BEFORE_GET_SUGGESTIONS';
export const AFTER_GET_SUGGESTIONS = 'CHAT__AFTER_GET_SUGGESTIONS';

const actions = {
    addMessage: createAction(ADD_MESSAGE),
    beforeAddBotMessage: createAction(BEFORE_ADD_BOT_MESSAGE),
    afterAddBotMessage: createAction(AFTER_ADD_BOT_MESSAGE),
    setBotResponding: createAction(SET_BOT_RESPONDING),
    addPollMessage: createAction(ADD_POLL_MESSAGE),
    afterGetSuggestions: createAction(AFTER_GET_SUGGESTIONS),
    beforeGetSuggestions: createAction(BEFORE_GET_SUGGESTIONS),
};

function getTimeout() {
    return (Math.random() + 0.2) * 1000;
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function sleep(milliseconds) {
    return new Promise(resolve => setTimeout(resolve, milliseconds))
}

const pushMessages = (suggestions, counter, dispatch, reset) => {
    const suggestion = suggestions[counter];

    return new Promise((resolve, reject) => {
        if (suggestion) {
            if (suggestion.random) {
                if (Math.random() > suggestion.random) {
                    dispatch(actions.beforeAddBotMessage());
                    document.getElementById('chart-area').scrollTop = document.getElementById('chart-area').clientHeight + 30000;
                    sleep(Math.random() * getTimeout())
                        .then(() => {
                            dispatch(addBotMessage(suggestion));
                            pushMessages(suggestions, counter + 1, dispatch);
                            document.getElementById('chart-area').scrollTop = document.getElementById('chart-area').clientHeight + 30000;
                        });
                } else {
                    pushMessages(suggestions, counter + 1, dispatch);
                }
            } else {
                dispatch(actions.beforeAddBotMessage());
                document.getElementById('chart-area').scrollTop = document.getElementById('chart-area').clientHeight + 30000;
                sleep(Math.random() * getTimeout())
                    .then(() => {
                        dispatch(addBotMessage(suggestion));
                        pushMessages(suggestions, counter + 1, dispatch);
                        document.getElementById('chart-area').scrollTop = document.getElementById('chart-area').clientHeight + 30000;
                    });
            }
        } else if (!suggestion) {
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
    document.getElementById('chart-area').scrollTop = document.getElementById('chart-area').clientHeight + 30000;

    sleep(300)
        .then(() => {
            pushMessages(suggestion.responses, 0, dispatch, suggestion.childrenCount);

            if (suggestion.childrenCount) {
                dispatch(getSuggestions(suggestion.id))
            } else {
                sleep(1000)
                    .then(() => {
                        dispatch(getSuggestions(0));
                        dispatch(actions.beforeAddBotMessage());
                        dispatch(actions.setBotResponding(true));

                        sleep(2000)
                            .then(() => {
                                dispatch(actions.setBotResponding(false));
                                dispatch(addBotMessage({ title: 'Ar dar reikia pagalbos ?' }));
                                document.getElementById('chart-area').scrollTop = document.getElementById('chart-area').clientHeight + 30000;
                            });
                    });
            }
        });
};

const addBotMessage = (suggestion) => (dispatch) => {
    if (suggestion.url || suggestion.photo) {
        const message = {
            type: 'bot',
            id: new Date().getTime(),
            data: suggestion,
        };

        dispatch(actions.addMessage(message));
    } else {
        const messageTitle = Array.isArray(suggestion.title)
            ? suggestion.title[getRandomInt(0, suggestion.title.length - 1)]
            : suggestion.title;

        const message = {
            type: 'bot',
            id: new Date().getTime(),
            message: messageTitle,
        };

        dispatch(actions.addMessage(message));
    }
};

const addPollMessage = (id) => (dispatch) => {
    dispatch(actions.beforeAddBotMessage());
    dispatch(actions.setBotResponding(true));

    setTimeout(() => {
        const titles = ['Atrodo yra klausimas į kurį galėtum atsakyti!', 'Turiu tau klausima...', 'Ką manai?'];
        dispatch(addBotMessage({ title: titles }));
        dispatch(actions.addMessage({
            type: 'bot',
            id: new Date().getTime(),
            pollId: id,
        }));
        dispatch(actions.setBotResponding(false));
    }, 1000);
};

const getSuggestions = (id) => (dispatch, getState) => {
    dispatch(actions.beforeAddBotMessage());
    restService.get(`/api/Suggestion/${id}`)
        .then((data) => {
            dispatch(actions.afterGetSuggestions({
                data,
                id,
            }));
        });
};

export default {
    addUserMessage,
    addBotMessage,
    beforeAddBotMessage: actions.beforeAddBotMessage,
    setBotResponding: actions.setBotResponding,
    addPollMessage,
    getSuggestions,
};
