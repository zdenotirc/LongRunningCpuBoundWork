from locust import HttpUser, task, between

class ApiUser(HttpUser):
    wait_time = between(1,5)

    def on_start(self):
        self.client.verify = False

    @task
    def getModels(self):
        self.client.get(url="/SlowOp")