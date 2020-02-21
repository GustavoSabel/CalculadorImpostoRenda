import React, { useState } from 'react';

import {Form, Container, Button, Card} from 'react-bootstrap';
import FormularioContribuinte from './FormularioContribuinte';

function Contribuintes(){

    return (<Container fluid>
        <FormularioContribuinte></FormularioContribuinte>
    </Container>)
}

export default Contribuintes;