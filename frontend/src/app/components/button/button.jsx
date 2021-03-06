import React from 'react';
import PropTypes from 'prop-types';
import { Button as ButtonEvergreen, Text } from 'evergreen-ui';

const Button = (props) => {
    const {
        title,
        onClick,
        disabled,
        appearance,
        intent,
        height,
    } = props;

    return (
        <ButtonEvergreen
            height={height}
            intent={intent}
            onClick={onClick}
            disabled={disabled}
            appearance={appearance}
        >
            <Text
                size={400}
            >
                {title}
            </Text>
        </ButtonEvergreen>
    );
};

Button.propTypes = {
    type: PropTypes.oneOf(['button', 'submit']),
    title: PropTypes.string.isRequired,
    onClick: PropTypes.func,
    color: PropTypes.oneOf(['primary', 'secondary', 'success', 'info', 'warning', 'danger', 'link']),
    disabled: PropTypes.bool,
    size: PropTypes.oneOf(['sm', 'md', 'lg']),
    block: PropTypes.bool,
};

Button.defaultProps = {
    type: 'button',
    color: 'primary',
    onClick: undefined,
    disabled: false,
    size: 'md',
    block: false,
};

export default Button;
