import { createAction } from 'redux-actions';

export const ADD_MESSAGE = 'CHAT__ADD_MESSAGE';

const actions = {
    addMessage: createAction(ADD_MESSAGE),
};

const addUserMessage = (suggestion) => (dispatch) => {
    const message = {
        type: 'user',
        message: suggestion.title,
    };

    dispatch(actions.addMessage(message));

    setTimeout(() => {
        suggestion.responses.forEach((response) => {
            if (!response.random) {
                dispatch(addBotMessage({ title: response.title }));
            } else {
                const showMessage = Math.random() > response.random;
                console.log(showMessage, response.random);
                if (showMessage) {
                    dispatch(addBotMessage({ title: response.title }));
                }
            }
        });
    }, 1000);
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
};
