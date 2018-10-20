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
        <h1>Sukurti naują pranešimą</h1>

        { error && <Alert color="danger">{ error }</Alert>}

        <Field
            name="notificationTitle"
            component={ TextField }
            placeholder="Antraštė"
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
            placeholder="Aprašymas"
            validate={
                [
                    validations.required,
                ]
            }
        />
        <Field name="notificationType" component="select" className={ styles['dropdown'] }>
            <option>Tipas</option>
            <option value="success">Sėkingas</option>
            <option value="warning">Įspėjimas</option>
            <option value="danger">Pavojingas</option>
            <option value="info">Informacinis</option>
        </Field>

        <Button
            title="Sukurti"
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
