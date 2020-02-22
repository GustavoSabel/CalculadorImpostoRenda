import React, { useState, useEffect } from 'react';
import { Container, Button } from 'react-bootstrap';
import Formulario from './Formulario';
import Lista from './Lista';
import ContribuinteService from '../services/ContribuinteService'

function Contribuinte() {

   const [contribuintes, setContribuintes] = useState([]);

   useEffect(() => {
      atualizarLista();
   }, []);

   const atualizarLista = async () => {
      var result = await ContribuinteService.obterTodos();
      if(result)
         setContribuintes(result);
   }

   const calcular = async () => {
      var salario = prompt("Salário mínimo");
      salario = parseFloat(salario);
      if(!salario) {
         alert("Salário informado é inválido. Informe somente números. Ex: \"1500.75\"");
      } else {
         var result = await ContribuinteService.calcular(salario);
         if(result)
            setContribuintes(result);
      }
   };

   return (<Container fluid>
      <Formulario atualizarLista={atualizarLista}/>
      <br/>
      <Lista contribuintes={contribuintes}/>
      <Button onClick={calcular}>Calcular IR<i className="fas fa-calculator"></i></Button>
   </Container>)
}

export default Contribuinte;