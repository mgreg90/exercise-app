import regeneratorRuntime from 'regenerator-runtime'
import page from "page"

import applyCustomKnockoutBindings from './misc/customKnockoutBindings'
import registerRoutes, { routes } from './misc/routes'
import router from './misc/router'

applyCustomKnockoutBindings()

const appBody = document.getElementById('APPLICATION_BODY')
registerRoutes(appBody)

let route = routes.HOME
const hashPath = window.location.hash?.slice(1)
if (hashPath !== '/') route = hashPath

router.update(route)