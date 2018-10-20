import { combineReducers } from 'redux';
import { reducer as formReducer } from 'redux-form';

import sessionReducer from 'app/pages/private/session/redux/reducer';
import chatReducer from 'app/components/chat/redux/reducer';

const appReducer = combineReducers({
    form: formReducer,
    session: sessionReducer,
    chat: chatReducer,
});

export default (state, action) => appReducer(state, action);
