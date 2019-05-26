<template>
  <q-page class="q-pa-sm bg-grey-2">
    <q-table
      dense
      separator="cell"
      title="Fornecedores"
      :data="fornecedores"
      :columns="columns"
      :filter="filter"
      :loading="loadingTable"
      row-key="name">
      <q-td slot="body-cell-action" slot-scope="props" :props="props">
        <q-btn dense size="sm" color="primary" icon="edit" @click="atualizarFornecedor(props.row)" class="q-mr-md"></q-btn>
        <q-btn dense size="sm" color="negative" icon="delete" @click="deletarFornecedor(props.row)"></q-btn>
      </q-td>
      <template v-slot:top-right>
        <q-input outlined dense debounce="300" v-model="filter" placeholder="Filtrar">
          <template v-slot:append>
            <q-icon name="search" />
          </template>
        </q-input>
      </template>
    </q-table>

    <q-dialog v-model="prompt" persistent>
      <q-card>
        <q-card-section>
          <div class="text-h6">Atualizar Fornecedor</div>
        </q-card-section>

        <q-card-section>
          <q-input outlined dense label="nome" autofocus @keyup.enter="prompt = false" />
        </q-card-section>

        <q-card-actions align="right" class="text-primary">
          <q-btn flat label="Cancelar" v-close-popup />
          <q-btn color="primary" label="Atualizar" @click="update()" />
        </q-card-actions>
      </q-card>
    </q-dialog>

  <div class="row">
    <div class="col-12 text-right">
      <q-btn :to="{name: 'cadastro-de-fornecedor'}" clickable tag="a" color="secondary" label="Novo" class="q-mt-md q-mb-md q-pa-md q-mr-md"/>
    </div>
  </div>

  </q-page>
</template>

<script>
import { $axios } from 'boot/axios'
import { date } from 'quasar'

export default {
  mounted () {
    this.carregarFornecedor()
  },
  data () {
    return {
      prompt: false,
      loadingTable: false,
      fornecedores: [],
      filter: '',
      columns: [
        { name: 'nome', label: 'Nome', field: 'nome', sortable: true, align: 'center' },
        { name: 'data_cadastro', label: 'Data Cadastro', field: 'data_cadastro', sortable: true, align: 'center', format: (val, row) => this.formatDate(val) },
        { name: 'cpf', label: 'CPF', field: 'cpf', sortable: true, align: 'center' },
        { name: 'cnpj', label: 'CNPJ', field: 'cnpj', sortable: true, align: 'center' },
        { name: 'nome_empresa', label: 'Empresa', field: 'nome_empresa', sortable: true, align: 'center' },
        { name: 'action', label: 'Ação', field: 'action', sortable: true, align: 'center' }
      ]
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

    simulateProgress (nr, ativo) {
      this[`loading${nr}`] = ativo
    },

    formatDate (dateTime) {
      return date.formatDate(dateTime, 'DD/MM/YYYY')
    },

    carregarFornecedor () {
      this.loadingTable = true
      $axios.get('Fornecedor')
        .then((response) => {
          this.fornecedores = response.data
        })
        .catch((erro) => {
          console.log(erro)
        })
        .finally(() => {
          this.loadingTable = false
        })
    },

    deletarFornecedor (row) {
      this.simulateProgress(1, true)
      console.log(row)
      row.empresa = null
      $axios.delete('Fornecedor', row)
        .then((res) => {
          this.msg('Fornecedor Deletado', 1)
        })
        .catch((err) => {
          this.msg('Erro na requisição', 2)
          console.log(err)
        })
        .finally(() => {
          this.$router.push('/fornecedor/lista-de-fornecedor')
        })
    },

    atualizarFornecedor (row) {
      this.prompt = true
    }
  }
}
</script>

<style>
</style>
