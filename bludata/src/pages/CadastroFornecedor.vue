<template>
  <q-page>
    <div class="container q-pa-md">
      <q-card>
        <div class="row justify-center">

          <q-input v-model="params.vnome" outlined label="Nome" class="col-2 q-pa-md"/>

          <q-toggle v-model="ecnpj" label="CNPJ" class="q-mb-md col-1"/>

          <q-input v-model="params.vcpf"
            outlined
            :label="ecnpj ? 'CNPJ':'CPF'"
            :mask="ecnpj ? '##.###.###/####-##' : '###.###.###-##'"
            class="col-2 q-pa-md"/>

          <q-select v-model="params.vempresa" :options="options.empresas" class="col-2 q-pa-md" outlined label="Empresa"/>

          <q-btn :loading="loading" color="green-9" label="Cadastrar" class="col-2 q-mt-md q-mb-md q-pa-md" @click="cadastrarFornecedor()" outline />

        </div>

        <div class="row justify-center">
          <q-input v-model="params.vrg" outlined label="RG" :class="'col-2 q-pa-md' + (ecnpj ? ' hidden' : '') " />
          <q-input outlined v-model="params.vdatnascimento" mask="####/##/##" label="Data Nascimento" :class="'col-2 q-pa-md' + (ecnpj ? ' hidden' : '') ">
            <template v-slot:append>
              <q-icon name="event" class="cursor-pointer">
                <q-popup-proxy>
                  <q-date v-model="params.vdatnascimento"/>
                </q-popup-proxy>
              </q-icon>
            </template>
          </q-input>

          <q-list dense bordered padding separator class="rounded-borders col-1">
          <q-btn flat round color="primary" icon="call" @click="openNovoNumero()" />add
          <q-item v-for="telefone in params.vtelefones" :key="telefone.numero" v-ripple>
            <q-item-section>
              {{ telefone.numero }}
            </q-item-section>
          </q-item>
          </q-list>

          <div class="col-2"></div>
          <div class="col-2"></div>
        </div>

      </q-card>

      <q-dialog v-model="prompt" persistent>
        <q-card>
          <q-card-section>
            <div class="text-h6">novo numero</div>
          </q-card-section>

          <q-card-section>
            <q-input outlined dense v-model="telefone" label="numero" autofocus @keyup.enter="prompt = false" />
          </q-card-section>

          <q-card-actions align="right" class="text-primary">
            <q-btn flat label="Cancelar" v-close-popup />
            <q-btn color="primary" icon="add" @click="novoNumero()" />
          </q-card-actions>
        </q-card>
      </q-dialog>

    </div>
  </q-page>
</template>

<script>
import { $axios } from 'boot/axios'
import { date } from 'quasar'

export default {
  mounted () {
    this.carregarEmpresas()
  },
  data () {
    return {
      prompt: false,
      loading: false,
      ecnpj: false,
      telefone: null,
      params: {
        vnome: null,
        vcpf: null,
        vempresa: null,
        vdatnascimento: null,
        vrg: null,
        vtelefones: []
      },
      options: {
        empresas: []
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

    simulateProgress (ativo) {
      this[`loading`] = ativo
    },

    carregarEmpresas () {
      $axios.get('Empresa')
        .then((response) => {
          response.data.forEach((value) => {
            this.options.empresas.push({
              label: value.nome_fantasia,
              value: value.cnpj
            })
          })
        })
        .catch((erro) => {
          console.log(erro)
        })
    },

    cadastrarFornecedor () {
      this.simulateProgress(true)
      var form = {
        nome: this.params.vnome,
        data_cadastro: date.formatDate(new Date(), 'YYYY-MM-DD'),
        cpf: this.ecnpj ? null : this.params.vcpf.replace(/[^0-9]/g, ''),
        cnpj: this.ecnpj ? this.params.vcpf.replace(/[^0-9]/g, '') : null,
        empresa_cnpj: this.params.vempresa.value,
        pessoa_fisica: this.ecnpj ? null : { cpf: this.params.vcpf.replace(/[^0-9]/g, ''), data_nascimento: this.params.vdatnascimento.split('/').join('-') },
        telefones: this.params.vtelefones
      }
      $axios.post('Fornecedor', form)
        .then((res) => {
          this.msg('Cadastrado com Sucesso :)', 1)
        })
        .catch((err) => {
          this.msg('Erro na requisição', 2)
          console.log(err)
        })
        .finally(() => {
          setInterval(() => {
            this.simulateProgress(false)
          }, 1000)
          this.$router.push('/fornecedor/lista-de-fornecedor')
        })
    },

    openNovoNumero () {
      this.prompt = true
    },

    novoNumero () {
      this.params.vtelefones.push({ numero: this.telefone })
      this.prompt = false
    }
  }
}
</script>

<style>
</style>
