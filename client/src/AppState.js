import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,
  /** @type {import('./models/Keep.js').Keep[]} */
  keeps: [],
  /** @type {import('./models/Keep.js').Keep[]} */
  activeProfileKeeps: [],
  /** @type {import('./models/Keep.js').Keep} */
  activeKeep: null,
  /** @type {import('./models/Profile.js').Profile} */
  activeProfile: null,
  /** @type {import('./models/Vault.js').Vault[]} */
  profileVaults: [],
  /** @type {import('./models/Vault.js').Vault} */
  activeVault: null,
  /** @type {import('./models/Vault.js').Vault[]} */
  accountVaults: [],
  /** @type {import('./models/VaultKeep.js').VaultKeep[]} */
  vaultKeeps: []

})

