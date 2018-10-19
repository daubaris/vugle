import React from 'react';
import {
    reduxForm,
    Field,
    Form,
    formPropTypes,
} from 'redux-form';

import {
    TextField,
    validations,
} from 'app/components/inputs';

import { Button } from 'app/components/button';

import styles from './notification-page.scss';

const NotificationForm = ({ handleSubmit, submitting, error }) => (
    <Form onSubmit={ handleSubmit }>
        { error && <Alert color="danger">{ error }</Alert>}

        <Field
            name="notificationTitle"
            component={ TextField }
            placeholder="Title"
            disabled={ submitting }
            validate={
                [
                    validations.required,
                ]
            }
        />

        <Field
            name="notificationText"
            component={ TextField }
            placeholder="Notification text"
            validate={
                [
                    validations.required,
                ]
            }
        />
        <Field name="notificationType" component="select" className={ styles['dropdown'] }>
            <option>Type</option>
            <option value="success">Success</option>
            <option value="warning">Warning</option>
            <option value="danger">Danger</option>
            <option value="info">Info</option>
        </Field>

        <Field
            name="notificationUrl"
            component={ TextField }
            placeholder="Url"
            validate={
                [
                    validations.required,
                ]
            }
        />

        <Button
            title="Submit"
            type="submit"
            size="lg"
            block
        />
    </Form>
);

NotificationForm.propTypes = {
    ...formPropTypes,
};

export default reduxForm({
    form: 'notification-form',
})(NotificationForm);
