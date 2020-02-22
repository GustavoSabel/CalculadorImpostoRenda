import React, { useState, useEffect } from 'react';
import { Container } from 'react-bootstrap';
import Formulario from './Formulario';
import Lista from './Lista';
import ContribuinteService from '../services/ContribuinteService'

function Contribuinte() {

   const [contribuintes, setContribuintes] = useState([]);

   useEffect(() => {
      setContribuintes(ContribuinteService.obterTodos());
   });

   const atualizarLista = () => {
      setContribuintes(ContribuinteService.obterTodos());
   }

   return (<Container fluid>
      <Formulario atualizarLista={atualizarLista}/>
      <Lista contribuintes={contribuintes}/>
   </Container>)
}

export default Contribuinte;