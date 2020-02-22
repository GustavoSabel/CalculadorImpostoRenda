import React, { useState } from 'react';

import {Form, Container, Button, Card, Row, Col} from 'react-bootstrap';

function Formulario({atualizarLista}){
    
    const [nome, setNome] = useState('');
    const [cpf, setCpf] = useState('');
    const [dependentes, setDependentes] = useState(0);
    const [salarioBruto, setSalarioBruto] = useState(0);
    
    async function handleSubmit(e) {
        e.preventDefault();
        e.stopPropagation();
        atualizarLista();
      //   var result = await AutenticadorService.autenticar(usuario, senha);
      //   if(result){
      //       props.logadoComSucesso();
      //   }
    };

    return (<div>
      <Form onSubmit={handleSubmit}>

         <Row>
            <Col sm="6" xl="4">
               <Form.Group controlId="Nome">
                  <Form.Label>Nome</Form.Label>
                  <Form.Control 
                     type="text" 
                     placeholder="Nome do Contribuinte" 
                     value={nome}
                     onChange={e => setNome(e.currentTarget.value)}>
                  </Form.Control>
               </Form.Group>
            </Col>
            <Col sm="6" xl="3">
               <Form.Group controlId="Cpf">
                  <Form.Label>CPF</Form.Label>
                  <Form.Control 
                     type="text" 
                     placeholder="CPF" 
                     value={cpf}
                     onChange={e => setCpf(e.currentTarget.value)}>
                  </Form.Control>
               </Form.Group>
            </Col>
            <Col sm="6" xl="2">
               <Form.Group controlId="Dependentes">
                  <Form.Label>Dependentes</Form.Label>
                  <Form.Control 
                     type="number" 
                     step="1"
                     placeholder="Dependentes" 
                     value={dependentes}
                     onChange={e => setDependentes(e.currentTarget.value)}>
                  </Form.Control>
               </Form.Group>
            </Col>
            <Col sm="6" xl="3">
               <Form.Group controlId="salarioBruto">
                  <Form.Label>Salário Bruto</Form.Label>
                  <Form.Control 
                     type="number" 
                     placeholder="Salário Bruto" 
                     value={salarioBruto}
                     onChange={e => setSalarioBruto(e.currentTarget.value)}>
                  </Form.Control>
               </Form.Group>
            </Col>
            <Col sm="12">
               <Button type="submit">
                  Cadastrar
                  <i style={{paddingLeft: 10}} className="fas fa-plus"></i>
               </Button>
            </Col>
         </Row>
      </Form>
    </div>)
}

export default Formulario;