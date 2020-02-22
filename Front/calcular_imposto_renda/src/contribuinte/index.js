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
      var result = await ContribuinteService.calcular();
      if(result)
         setContribuintes(result);
   };

   return (<Container fluid>
      <Formulario atualizarLista={atualizarLista}/>
      <br/>
      <Lista contribuintes={contribuintes}/>
      <Button onClick={calcular}>Calcular <i className="fas fa-calculator"></i></Button>
   </Container>)
}

export default Contribuinte;