import React from 'react';
import { Container, Row, Col, Card, CardBody } from 'reactstrap';
import Chart from '../../../components/chart/chart';

class ChartPage extends React.PureComponent {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <Container>
                <Row>
                    <Col lg={{ size: 12 }}>
                        <Card>
                            <CardBody>
                                <Chart/>
                            </CardBody>
                        </Card>
                    </Col>
                </Row>
            </Container>
        );
    }
}

export default ChartPage;
