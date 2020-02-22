import Axios from "axios";

const URL_BASE = 'http://localhost:5000/api/contribuinte';

const ContribuinteService = {

   inserir: async (contribuinte) => {
      try{
         var result = await Axios.post(URL_BASE, contribuinte);
         return result.data;
      } catch(error){
         tratarErro(error);
      }
   },

   obter: async (id) => {
      try {
         var result = await Axios.get(URL_BASE, id);
         return result.data;
      } catch(error){
         tratarErro(error);
      }
   },

   obterTodos: async () => {
      try {
         var result = await Axios.get(URL_BASE);
         return result.data;
      } catch(error){
         tratarErro(error);
      }
   },

   calcular: async (salarioMinimo) => {
      try {
         var result = await Axios.post(URL_BASE + '/calcularImpostoRenda', ({salarioMinimo}));
         return result.data;
      } catch(error){
         tratarErro(error);
      }
   },
}

function tratarErro(error){
   console.log(error.response);
   alert("Ocorreu um erro");
}

export default ContribuinteService;
