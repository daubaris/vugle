import { handleActions } from 'redux-actions';

import {
    ADD_MESSAGE,
} from './actions';

export function getInitialState() {
    return {
        messages: [],
    };
}

export default handleActions({
    [ADD_MESSAGE]: (state, { payload: message }) => ({
        ...state,
        messages: [
            ...state.messages,
            message,
        ]
    }),
}, getInitialState());
