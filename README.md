## Solution 1
<div align="center" style="margin-bottom:20px">
</div>

The first solution uses the static ServiceDependencyProvider to inject infrastructure objects within the quote domain model. The static ServiceDependencyProvider is initialized during application configuration and provides dependencies from the HTTP request context. This guarantees that dependencies are taken from the service scope, avoiding the additional creation of objects.
