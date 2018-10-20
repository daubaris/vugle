import React from 'react';
import {
    reduxForm,
    Field,
    Form,
    formPropTypes,
    FieldArray,
} from 'redux-form';

import {
    TextField,
    validations,
} from 'app/components/inputs';

import { Button } from 'app/components/button';

const renderOptions = ({ fields, meta: { error, submitFailed } }) => (
    <div>
        <button
            type="button" 
            onClick={ () => fields.push({}) }
            style={{ marginBottom: '20px' }}
        >
            Pridėti pasirinkimą
        </button>
        {
            submitFailed
            && error
            && (
                <span>
                    {error}
                </span>
            )
        }
        {fields.map((member, index) => (
            <div key={ index }>
                <Field
                    name={ `${member}.title` }
                    type="text"
                    component={ TextField }
                    label="Pasirinkimo pavadinimas"
                />
            </div>))
        }
    </div>
);

const PollForm = ({ handleSubmit, submitting, error }) => (
    <Form onSubmit={ handleSubmit }>
        <h1>Sukurti naują apklausą</h1>

        { error && <Alert color="danger">{ error }</Alert>}

        <Field
            name="title"
            component={ TextField }
            placeholder="Pavadinimas"
            disabled={ submitting }
            validate={
                [
                    validations.required,
                ]
            }
        />

        <Field
            name="description"
            component={ TextField }
            placeholder="Aprašymas"
            validate={
                [
                    validations.required,
                ]
            }
        />

        <FieldArray name="options" component={ renderOptions } />

        <Button
            title="Sukurti apklausą"
            type="submit"
            size="lg"
            block
            disabled={ submitting }
        />
    </Form>
);

PollForm.propTypes = {
    ...formPropTypes,
};

export default reduxForm({
    form: 'poll-form',
})(PollForm);
