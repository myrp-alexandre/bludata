
const routes = [
  {
    path: '/',
    component: () => import('layouts/MyLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Index.vue') }
    ]
  },
  {
    path: '/empresa',
    component: () => import('layouts/MyLayout.vue'),
    children: [
      { path: 'cadastro-de-empresa', title: 'Cadastro de Empresa', name: 'cadastro-de-empresa', component: () => import('pages/Empresa.vue') }
    ]
  },
  {
    path: '/fornecedor',
    component: () => import('layouts/MyLayout.vue'),
    children: [
      { path: 'lista-de-fornecedor', title: 'Listagem de Fornecedor', name: 'lista-de-fornecedor', component: () => import('pages/ListaFornecedor.vue') },
      { path: 'cadastro-de-fornecedor', title: 'Cadastro de Fornecedor', name: 'cadastro-de-fornecedor', component: () => import('pages/CadastroFornecedor.vue') }
    ]
  }
]

// Always leave this as last one
if (process.env.MODE !== 'ssr') {
  routes.push({
    path: '*',
    component: () => import('pages/Error404.vue')
  })
}

export default routes
