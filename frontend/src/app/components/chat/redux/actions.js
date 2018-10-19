import { createAction } from 'redux-actions';

export const ADD_MESSAGE = 'CHAT__ADD_MESSAGE';

const actions = {
    addMessage: createAction(ADD_MESSAGE),
};

export default {
    addUserMessage: (suggestion) => (dispatch) => {
        const message = {
            type: 'user',
            message: suggestion.title,
        };

        dispatch(actions.addMessage(message));
    },
    addBotMessage: (suggestion) => (dispatch) => {
        const message = {
            type: 'bot',
            id: new Date().getTime(),
            message: suggestion.title,
        };

        dispatch(actions.addMessage(message));
    }
};
