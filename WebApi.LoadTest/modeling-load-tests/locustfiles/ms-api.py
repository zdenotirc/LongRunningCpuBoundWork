from locust import HttpUser, task, between

class ApiUser(HttpUser):
    wait_time = between(1,5)

    @task
    def getModels(self):
        self.client.get(url="/hello")