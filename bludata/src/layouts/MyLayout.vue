<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated class="bg-grey-2 text-grey-9">
      <q-toolbar accent>
        <q-btn
          flat
          dense
          round
          @click="leftDrawerOpen = !leftDrawerOpen"
          aria-label="Menu"
        >
          <q-icon name="menu" />
        </q-btn>

        <q-toolbar-title>
          {{ formatName($route.name) }}
        </q-toolbar-title>

      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      bordered
      content-class="bg-grey-2"
      :width="260"
    >

      <q-list>
        <div class="row">
          <div class="col-12 text-center">
            <q-img
              src="statics/logo-01.png"
              style="width: 80%;"></q-img>
          </div>
        </div>

          <q-item :to="{name: 'cadastro-de-empresa'}" clickable tag="a" class="q-ml-lg q-mt-lg">
            <q-item-section avatar>
              <q-icon name="business" />
            </q-item-section>
            <q-item-section>
              <q-item-label>Empresa</q-item-label>
            </q-item-section>
          </q-item>

          <q-item :to="{name: 'lista-de-fornecedor'}" clickable tag="a" class="q-ml-lg">
            <q-item-section avatar>
              <q-icon name="insert_emoticon" />
            </q-item-section>
            <q-item-section>
              <q-item-label>Fornecedor</q-item-label>
            </q-item-section>
          </q-item>

      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import { openURL } from 'quasar'

export default {
  name: 'MyLayout',
  data () {
    return {
      leftDrawerOpen: this.$q.platform.is.desktop
    }
  },
  methods: {
    openURL,
    formatName (title) {
      try {
        return title.split('-').join(' ').toUpperCase()
      } catch (e) {
        return ''
      }
    }
  }
}
</script>

<style>
</style>
