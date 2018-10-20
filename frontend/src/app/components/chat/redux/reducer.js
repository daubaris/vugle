import { handleActions } from 'redux-actions';

import {
    ADD_MESSAGE,
    BEFORE_ADD_BOT_MESSAGE,
    AFTER_ADD_BOT_MESSAGE,
    SET_BOT_RESPONDING,
    BEFORE_GET_SUGGESTIONS,
    AFTER_GET_SUGGESTIONS,
} from './actions';

export function getInitialState() {
    return {
        messages: [],
        waitingForBotResponse: false,
        botResponding: false,
        suggestions: {
            id: 0,
            loading: false,
            suggestions: [],
        }
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
    [SET_BOT_RESPONDING]: (state, { payload }) => ({
        ...state,
        botResponding: payload,
    }),
    [BEFORE_GET_SUGGESTIONS]: (state, { payload }) => ({
        ...state,
        suggestions: {
            ...state.suggestions,
            loading: true,
        }
    }),
    [AFTER_GET_SUGGESTIONS]: (state, { payload }) => ({
        ...state,
        suggestions: {
            ...state.suggestions,
            loading: false,
            suggestions: payload.data,
            id: payload.id,
        }
    }),
}, getInitialState());
