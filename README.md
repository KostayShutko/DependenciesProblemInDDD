## Solution 1
<div align="center" style="margin-bottom:20px">
  <img src="https://github.com/KostayShutko/Manufacturing/assets/26852817/21428027-3f7b-4768-ab11-820aa31f9e3e"/>
</div>

The first solution uses the static ServiceDependencyProvider to inject infrastructure objects within the quote domain model. The static ServiceDependencyProvider is initialized during application configuration and provides dependencies from the HTTP request context. This guarantees that dependencies are taken from the service scope, avoiding the additional creation of objects.
