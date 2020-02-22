import React from 'react';

import {Form, Container, Button, Card, Tab, Table} from 'react-bootstrap';

function Lista({contribuintes}) {
   return (
   <Table striped bordered hover size="sm">
      <thead>
         <tr>
            <th>Nome</th>
            <th>CPF</th>
            <th>Num. Dep.</th>
            <th>Salário Bruto</th>
            <th>IR</th>
         </tr>
      </thead>
      <tbody>
         {contribuintes && contribuintes.map(c => criarLinha(c))}
      </tbody>
   </Table>)

   function criarLinha(contrib) {
      return (<tr>
         <td>{contrib.nome}</td>
         <td>{contrib.cpf}</td>
         <td>{contrib.numeroDependentes}</td>
         <td>{contrib.rendaMensalBruta}</td>
         <td>{contrib.impostoRenda && 'R$' + contrib.impostoRenda?.toFixed(2)}</td>
      </tr>)
   }
}

export default Lista;