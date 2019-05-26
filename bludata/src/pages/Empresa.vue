<template>
  <q-page>
    <div class="container q-pa-md">
      <q-card>
        <div class="row justify-center">

          <q-input v-model="params.vcnpj" outlined label="CNPJ" mask="##.###.###/####-##" class="col-2 q-pa-md"/>

          <q-input v-model="params.vnomefantasia" outlined label="Nome Fantasia" class="col-2 q-pa-md"/>

          <q-select v-model="params.vestado" :options="options.estado" class="col-2 q-pa-md" outlined label="Estado"/>

          <q-btn :loading="loading1" color="green-9" label="Cadastrar" class="col-2 q-mt-md q-mb-md q-pa-md" @click="cadastrarEmpresa()" outline />

        </div>

      </q-card>
    </div>
  </q-page>
</template>

<script>
import { $axios } from 'boot/axios'

export default {
  mounted () {
    this.carregarEstados()
  },
  data () {
    return {
      loading1: false,
      options: {
        estado: []
      },
      params: {
        vestado: null,
        vcnpj: null,
        vnomefantasia: null
      }
    }
  },
  methods: {
    msg (texto, tipo) {
      this.$q.notify({
        color: tipo === 1 ? 'positive' : 'negative',
        textColor: 'white',
        icon: tipo === 1 ? 'check' : 'cancel',
        message: texto,
        position: 'top-right',
        timeout: 8000
      })
    },

    simulateProgress (number, ativo) {
      this[`loading${number}`] = ativo
    },

    carregarEstados () {
      $axios.get('Estado')
        .then((response) => {
          response.data.forEach((value) => {
            this.options.estado.push({
              label: value.sigla,
              value: value.estado_id
            })
          })
        })
        .catch((erro) => {
          console.log(erro)
        })
    },

    cadastrarEmpresa () {
      this.simulateProgress(1, true)
      var form = {
        cnpj: this.params.vcnpj.replace(/[^0-9]/g, ''),
        nome_fantasia: this.params.vnomefantasia,
        estado_id: this.params.vestado.value
      }
      $axios.post('Empresa', form)
        .then((res) => {
          this.msg('Sucesso :)', 1)
        })
        .catch((err) => {
          this.msg('Erro na requisição', 2)
          console.log(err)
        })
        .finally(() => {
          this.simulateProgress(1, false)
        })
    }
  }
}
</script>

<style>
</style>
