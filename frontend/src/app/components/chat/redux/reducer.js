import { handleActions } from 'redux-actions';

import {
    ADD_MESSAGE,
    BEFORE_ADD_BOT_MESSAGE,
    AFTER_ADD_BOT_MESSAGE,
} from './actions';

export function getInitialState() {
    return {
        messages: [],
        waitingForBotResponse: false,
    };
}

export default handleActions({
    [ADD_MESSAGE]: (state, { payload: message }) => {
        return {
            ...state,
            messages: [
                ...state.messages,
                message,
            ],
            waitingForBotResponse: false
        };
    },
    [BEFORE_ADD_BOT_MESSAGE]: (state) => ({
        ...state,
        waitingForBotResponse: true,
    }),
    [AFTER_ADD_BOT_MESSAGE]: (state) => ({
        ...state,
        waitingForBotResponse: false,
    }),
}, getInitialState());
